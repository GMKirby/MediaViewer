using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MediaViewer.Models
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);

        ObservableCollection<string> GetNames(int anAmount);


        ObservableCollection<Person> GetPeople(int anAmount);
    }
}
