﻿using FormsChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsChat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPageResize : ContentPage
	{
        MainViewModel vm;
        public ChatPageResize ()
		{
            BindingContext = vm = new MainViewModel();
            InitializeComponent ();


            //MessagingCenter.Subscribe<MainViewModel>(this, "EntryAdded", (sender) => {
            //    MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.Start, false);
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.DataAdded += Vm_DataAdded;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            vm.DataAdded -= Vm_DataAdded;
        }

        private void Vm_DataAdded(object sender, EventArgs e)
        {
            MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.Start, true);
        }

        private void EntryText_Completed(object sender, EventArgs e)
        {
            EntryText.Focus();
            //var x = MessageListView.ItemsSource;
            //MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.Start, false);
            
        }
    }
}