namespace FormulaOneApp.Classic.Core
{
    using Cirrious.CrossCore.IoC;
    using Cirrious.CrossCore;
    using ErgastAPI.Services.Circuits;
    using ErgastAPI.Services.Driver;
    using ErgastAPI.Services.Race;
    using ErgastAPI.Services.Standings;

    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IDriverService, DriverService>();
            Mvx.RegisterType<IStandingService, StandingService>();
            Mvx.RegisterType<IRaceService, RaceService>();
            Mvx.RegisterType<ICircuitService, CircuitService>();

            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}