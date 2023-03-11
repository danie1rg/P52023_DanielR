using P52023_DanielR.Forms;
using System.Windows.Forms;

namespace P52023_DanielR
{
    public static class Globales
    {
        //estas propiedades al pertenecer a una clase static se auto instancia
        //y se puede obtener acceso a ellas en la globalidad de la aplicación
        public static Form MiFormPrincipal = new Forms.FrmMDI();

        public static Forms.FrmUsuariosGestion MiFormGestionUsuarios = new Forms.FrmUsuariosGestion();

    }
}
