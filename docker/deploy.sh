#!/bin/bash
./build.sh
if [ $? -ne 0 ]; then
    echo "build error!"
    exit 1
fi
echo "Push docker image to registry 192.168.6.1:5000 ..."
docker tag beginor/owin-app 192.168.6.1:5000/beginor/owin-app \
    && docker push 192.168.6.1:5000/beginor/owin-app \
    && docker rmi 192.168.6.1:5000/beginor/owin-app \
    && docker tag beginor/owin-app:$(date +%Y%m%d) 192.168.6.1:5000/beginor/owin-app:$(date +%Y%m%d) \
    && docker push 192.168.6.1:5000/beginor/owin-app:$(date +%Y%m%d) \
    && docker rmi 192.168.6.1:5000/beginor/owin-app:$(date +%Y%m%d) \
    && docker tag beginor/postgis:9.5 192.168.6.1:5000/beginor/postgis:9.5 \
    && docker push 192.168.6.1:5000/beginor/postgis:9.5 \
    && docker rmi 192.168.6.1:5000/beginor/postgis:9.5
if [ $? -ne 0 ]; then
    echo "Push docker image to registry 192.168.6.1:5000 error!"
    exit 2
fi
echo "Create deploy config ..."
mkdir -p deploy/jexus/conf deploy/jexus/log deploy/jexus/web/assets/ deploy/postgres/data \
    && cp docker-compose.yml deploy \
    && cp jexus-conf deploy/jexus/conf/default \
    && sed 's/debug="true"/debug="false"/g' ../server/src/OwinApp.Entry/bin/Release/net461/Beginor.OwinApp.Entry.exe.config > deploy/jexus/web/web.config \
    && sed 's/value="DEBUG"/value="ERROR"/g' ../server/src/OwinApp.Entry/bin/Release/net461/log.config > deploy/jexus/web/log.config \
    && sed 's/127\.0\.0\.1/postgres/g' ../server/src/OwinApp.Entry/bin/Release/net461/hibernate.config > deploy/jexus/web/hibernate.config \
    && cp ../server/src/OwinApp.Entry/bin/Release/net461/windsor.config deploy/jexus/web/windsor.config
if [ $? -ne 0 ]; then
    echo "Create deploy config error!"
    exit 3
fi
echo "Copy deploy files to docker server ..."
scp -r deploy ubuntu@192.168.6.1:~/owin-app && rm -rf deploy
if [ $? -ne 0 ]; then
    echo "Copy deploy files to docker server error!"
    exit 3
fi
echo "Execute update script on docker server ..."
ssh ubuntu@192.168.6.1 -t '
cp -rv owin-app Documents/docker/
rm -rf owin-app
cd Documents/docker/owin-app
docker-compose down
docker rmi 192.168.6.1:5000/beginor/owin-app
docker-compose up -d
'
