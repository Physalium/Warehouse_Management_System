using System;
using System.Collections.Generic;
using System.Text;

using Warehouse_Management.Data.Repositories;

namespace Warehouse_Management.Data
{
    internal class WarehouseManagementData : IDisposable
    {
        private bool disposedValue;

        public WarehousemanagementContext db { get; set; } = new WarehousemanagementContext();
        public CityRepo CityRepo { get; set; }
        public CustomerRepo CustomerRepo { get; set; }
        public TruckRepo TruckRepo { get; set; }
        public WarehouseRepo WarehouseRepo { get; set; }
        public OrderRepo OrderRepo { get; set; }

        public WarehouseManagementData()
        {
            CityRepo = new CityRepo(db);
            CustomerRepo = new CustomerRepo(db);
            TruckRepo = new TruckRepo(db);
            WarehouseRepo = new WarehouseRepo(db);
            OrderRepo = new OrderRepo(db);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~WarehouseManagementData()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}