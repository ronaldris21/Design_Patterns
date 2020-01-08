

namespace DLL.Patterns
{
    public class SingletonRepository
    {
        //Encapsulacion es el nivel de acceso

        #region Atributos

        private static SingletonRepository instancia; //Atributos con minusculas 
        private RepositoryPersona repository;
        
        #endregion

        #region Propiedades
        public static SingletonRepository Instancia //Propieddades mayusculas
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new SingletonRepository();
                }
                return instancia;
            }
        }

        public RepositoryPersona Repository { get { return this.repository; } }
        #endregion


        #region Constructor
        public SingletonRepository()
        {
            this.repository = new RepositoryPersona();
        }
        #endregion

    }
}
