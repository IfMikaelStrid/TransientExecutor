# TransientExecutor
Transient executor for net core >= 3.0

Add to Startup.cs with:
  services.AddTransient<ITransientService, TransientService>();
