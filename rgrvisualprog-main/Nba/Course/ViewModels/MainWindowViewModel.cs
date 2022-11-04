using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using Course.Models;
using Course.Models.StaticTabs;
using Course.Models.Database;

namespace Course.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        Models.Database.NbaContext data;

        public Models.Database.NbaContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new Models.Database.NbaContext();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new MatchTab("Match", Data.Matches));
            Tabs.Add(new DivisionTab("Division", Data.Divisions));
            Tabs.Add(new PlayerStatTab("Player", Data.Players));
            Tabs.Add(new CityTab("City", Data.Cities));
            Tabs.Add(new ClubTab("Club", Data.Clubs));
            Tabs.Add(new ConferenTab("Conferen", Data.Conferens));
            Tabs.Add(new StatsMatchTab("StatsMatch", Data.StatsMatches));
            Tabs.Add(new StatsPlayerInMatchTab("StatsPlayerInMatchTab", Data.StatsPlayerInMatches));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
        }
    }
}
