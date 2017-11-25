using System;
using Beginor.AppFx.Core;
using Castle.Core;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Beginor.OwinApp.Test {

    public abstract class WindsorTest : IDisposable {

        protected IWindsorContainer Container { get; private set; }
        private IDisposable scope;

        protected WindsorTest() {
            SetupContainer();
            scope = Container.BeginScope();
        }

        ~WindsorTest() {
            Dispose(false);
        }

        protected void SetupContainer() {
            Container = new WindsorContainer();
            Container.Register(
                Component.For<IWindsorContainer>().Instance(Container)
            );
            Container.Install(
                Configuration.FromXmlFile("windsor.config"),
                // 根据具体应用的 Installer 进行修改
                FromAssembly.Named("Beginor.OwinApp.Data"),
                FromAssembly.Named("Beginor.OwinApp.Model"),
                FromAssembly.Named("Beginor.OwinApp.Logic"),
                FromAssembly.Named("Beginor.OwinApp.Security"),
                FromAssembly.Named("Beginor.OwinApp.Api")
            );
            var startables = Container.ResolveAll<IStartable>();
            foreach (var startable in startables) {
                startable.Start();
            }
            PostContainerSetup();
        }

        protected virtual void PostContainerSetup() { }

        public void Dispose() {
            Dispose(true);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                scope.Dispose();
            }
        }

    }

    public abstract class WindsorTest<TTarget> : WindsorTest {

        protected TTarget Target {
            get {
                return TargetId.IsNullOrEmpty()
                    ? Container.Resolve<TTarget>()
                    : Container.Resolve<TTarget>(TargetId);
            }
        }

        protected string TargetId { get; }

        protected WindsorTest() { }

        protected WindsorTest(string targetId) {
            Argument.NotNullOrEmpty(targetId, nameof(targetId));
            TargetId = targetId;
        }

    }

}
