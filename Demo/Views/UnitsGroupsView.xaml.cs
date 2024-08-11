﻿using UnitsConversionDemo.ViewModels;
using DigitalProduction.UI;
using Thor.Units;
using CommunityToolkit.Mvvm.Input;

namespace UnitsConversionDemo;

public partial class UnitsGroupsView : DigitalProductionMainPage
{
	#region Construction

	public UnitsGroupsView()
	{
		InitializeComponent();
	}

	#endregion

	#region Event Handlers
	
	async void OnNew(object sender, EventArgs eventArgs)
	{
		UnitsViewModel? unitsViewModel = BindingContext as UnitsViewModel;
		System.Diagnostics.Debug.Assert(unitsViewModel != null);

		//ConfigurationViewModel	viewModel	= new(Interface.ConfigurationList?.ConfigurationNames ?? []);
		//ConfigurationView		view		= new(viewModel);
		//object?					result		= await Shell.Current.ShowPopupAsync(view);

		//if (result is bool boolResult && boolResult)
		//{
		//	UnitsViewModel?.Insert(viewModel.Configuration);
		//}
	}

	async void OnEdit(object sender, EventArgs eventArgs)
	{
		UnitsViewModel? unitsViewModel = BindingContext as UnitsViewModel;
		System.Diagnostics.Debug.Assert(unitsViewModel != null);
		System.Diagnostics.Debug.Assert(unitsViewModel.UnitsConverter != null);

		//UnitGroupViewModel	viewModel	= new(unitsViewModel.UnitsConverter, unitsViewModel.SelectedItem!);
		//UnitsGroupView		view		= new(viewModel);
		
		await Shell.Current.GoToAsync(nameof(UnitsGroupView), true, new Dictionary<string, object>
		{
			{"UnitsConverter",  unitsViewModel.UnitsConverter},
			{"UnitGroup",  unitsViewModel.SelectedItem!}
		});

		//object?                 result      = await Shell.Current.ShowPopupAsync(view);

		//if (result is bool boolResult && boolResult)
		//{
		//	unitsViewModel.ReplaceSelected(viewModel.UnitGroup);
		//}
	}

	async void OnDelete(object sender, EventArgs eventArgs)
	{
		bool result = await DisplayAlert("Delete", "Delete the selected item, do you wish to continue?", "Yes", "No");

		if (result)
		{
			UnitsViewModel? viewModel = BindingContext as UnitsViewModel;
			viewModel?.Delete();
		}
	}

	#endregion

}