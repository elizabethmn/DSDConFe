//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace STDDatos
{
    public partial class BDDOCUMENTUMEntities : ObjectContext
    {
        public const string ConnectionString = "name=BDDOCUMENTUMEntities";
        public const string ContainerName = "BDDOCUMENTUMEntities";
    
        #region Constructors
    
        public BDDOCUMENTUMEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        public BDDOCUMENTUMEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        public BDDOCUMENTUMEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Tramite> Tramite
        {
            get { return _tramite  ?? (_tramite = CreateObjectSet<Tramite>("Tramite")); }
        }
        private ObjectSet<Tramite> _tramite;
    
        public ObjectSet<Tupa> Tupa
        {
            get { return _tupa  ?? (_tupa = CreateObjectSet<Tupa>("Tupa")); }
        }
        private ObjectSet<Tupa> _tupa;
    
        public ObjectSet<Solicitante> Solicitante
        {
            get { return _solicitante  ?? (_solicitante = CreateObjectSet<Solicitante>("Solicitante")); }
        }
        private ObjectSet<Solicitante> _solicitante;
    
        public ObjectSet<Cargo> Cargo
        {
            get { return _cargo  ?? (_cargo = CreateObjectSet<Cargo>("Cargo")); }
        }
        private ObjectSet<Cargo> _cargo;
    
        public ObjectSet<Expediente> Expediente
        {
            get { return _expediente  ?? (_expediente = CreateObjectSet<Expediente>("Expediente")); }
        }
        private ObjectSet<Expediente> _expediente;

        #endregion
    }
}
