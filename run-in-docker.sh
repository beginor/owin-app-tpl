#!/bin/bash
if [ ! -d "$(pwd)/jexus/log" ]; then
    mkdir -p "$(pwd)/jexus/log"
fi

docker run \
    --detach \
    --name jexus-dev \
    --restart unless-stopped \
    --publish 5824:80 \
    --volume $(pwd)/server/src/OwinApp.Entry:/var/www/default \
    --volume $(pwd)/jexus/conf/default:/usr/jexus/siteconf/default:ro \
    --volume $(pwd)/jexus/log:/usr/jexus/log \
    beginor/jexus-x64:5.8.2
