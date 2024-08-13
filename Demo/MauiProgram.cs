﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Media;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using UnitsConversionDemo.ViewModels;

namespace UnitsConversionDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa_solid.ttf", "FontAwesome");
			});

		#if DEBUG
			builder.Logging.AddDebug();
		#endif
		
		RegisterViewsAndViewModels(builder.Services);
		RegisterEssentials(builder.Services);

		return builder.Build();
	}

	static void RegisterViewsAndViewModels(IServiceCollection services)
	{
		services.AddSingleton<ParsingViewModel>();
		services.AddSingleton<ParseView>();
		services.AddTransient<UnitsGroupView>();
		services.AddTransient<UnitGroupViewModel>();
	}


	static void RegisterEssentials(in IServiceCollection services)
	{
		services.AddSingleton<IFileSaver>(FileSaver.Default);
		services.AddSingleton<IFolderPicker>(FolderPicker.Default);
		services.AddSingleton<ISpeechToText>(SpeechToText.Default);
		services.AddSingleton<ITextToSpeech>(TextToSpeech.Default);
	}
}
