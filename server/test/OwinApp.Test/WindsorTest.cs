using System;
using Beginor.AppFx.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;

namespace Beginor.OwinApp.Test {

    public abstract class WindsorTest {

        protected IWindsorContainer Container { get; private set; }

        [SetUp]
        public virtual void Setup() {
            Container = new WindsorContainer();
            Container.Register(
                Component.For<IWindsorContainer>().Instance(Container)
            );
            Container.Install(
                Configuration.FromXmlFile("windsor.config"),
                FromAssembly.Named("Beginor.OwinApp.Data"),
                FromAssembly.Named("Beginor.OwinApp.Model"),
                FromAssembly.Named("Beginor.OwinApp.Logic"),
                FromAssembly.Named("Beginor.OwinApp.Security"),
                FromAssembly.Named("Beginor.OwinApp.Api")
            );
        }

    }

    public abstract class WindsorTest<TTarget> : WindsorTest {

        protected TTarget Target { get; private set; }

        protected string TargetId { get; }

        public WindsorTest() { }

        public WindsorTest(string targetId) {
            Argument.NotNullOrEmpty(targetId, nameof(targetId));
            TargetId = targetId;
        }

        public override void Setup() {
            base.Setup();
            Target = TargetId.IsNullOrEmpty() ? Container.Resolve<TTarget>()
                : Container.Resolve<TTarget>(TargetId);
        }

    }

}
