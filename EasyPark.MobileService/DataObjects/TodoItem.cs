using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}