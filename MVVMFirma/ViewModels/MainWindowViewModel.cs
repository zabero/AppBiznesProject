using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media;
using System.Net.Security;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands



        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }


        private BaseCommand _showAppSettings;
        public ICommand ShowAppSettings
        {
            get
            {
                if (_showAppSettings == null)
                    _showAppSettings = new BaseCommand(() => AddWorkspaceOne(new AppSettingsViewModel()));
                return _showAppSettings;
            }
        }


         

        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);


            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Ustawienia",
                    new BaseCommand(() => this.AddWorkspaceOne(new AppSettingsViewModel()))),
                new CommandViewModel(
                    "Dodaj ustawienie",
                    new BaseCommand(() => this.AddWorkspaceOne(new AppSettingsAddViewModel()))),

                new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.AddWorkspaceOne(new CustomersViewModel()))),

                new CommandViewModel(
                    "Dodaj Klienta",
                    new BaseCommand(() => this.AddWorkspaceOne(new CustomersAddViewModel()))),

                new CommandViewModel(
                    "Użytkownicy",
                    new BaseCommand(() => this.AddWorkspaceOne(new UsersViewModel()))),

                new CommandViewModel(
                    "Dodaj użytkownika",
                    new BaseCommand(() => this.AddWorkspaceOne(new UserAddViewModel()))),

                new CommandViewModel(
                    "Kategorie Voucherów",
                    new BaseCommand(() => this.AddWorkspaceOne(new VoucherCategoriesViewModel()))),

                new CommandViewModel(
                    "Dodaj Kategorie Voucherów",
                    new BaseCommand(() => this.AddWorkspaceOne(new VoucherCategoriesAddViewModel()))),
                
                new CommandViewModel(
                    "Płatności",
                    new BaseCommand(() => this.AddWorkspaceOne(new PaymentsViewModel()))),
                new CommandViewModel(
                    "Preferencje użytkownika",
                    new BaseCommand(() => this.AddWorkspaceOne(new CustomerPreferencesViewModel()))),
                new CommandViewModel(
                    "Powiadomienia",
                    new BaseCommand(() => this.AddWorkspaceOne(new NotificationsViewModel()))),
                new CommandViewModel(
                    "Rabaty",
                    new BaseCommand(() => this.AddWorkspaceOne(new OrderDiscountsViewModel()))),

            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void AddWorkspaceOne(WorkspaceViewModel workspace)
        {
            var existingWorkspace = this.Workspaces.FirstOrDefault(w => w.GetType() == workspace.GetType());

            if (existingWorkspace == null)
            {
                this.Workspaces.Add(workspace);
                existingWorkspace = workspace;
            }

            this.SetActiveWorkspace(existingWorkspace);
        }



        //private void ShowAllTowar()
        //{
        //    WszystkieTowaryViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
        //        as WszystkieTowaryViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new WszystkieTowaryViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.SetActiveWorkspace(workspace);
        //}
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void open(string name)
        {
            if (name == "KlienciAdd")
                this.AddWorkspaceOne(new CustomersAddViewModel());
            if (name == "UstawieniaAdd")
                this.AddWorkspaceOne(new AppSettingsAddViewModel());
            if (name == "PowiadomieniaAdd")
                this.AddWorkspaceOne(new NotificationsAddViewModel());
            if (name == "RabatyAdd")
                this.AddWorkspaceOne(new OrderDiscountsAddViewModel());
        }
        #endregion
    }
}
