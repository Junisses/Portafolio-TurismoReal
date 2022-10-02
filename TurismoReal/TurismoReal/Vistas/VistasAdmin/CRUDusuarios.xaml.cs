using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{

    public partial class CRUDusuarios : Page
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CE_Usuarios objeto_CE_Usuarios = new CE_Usuarios();
        readonly CN_TipoUsuarioFK objeto_CN_TipoUsuarioFK = new CN_TipoUsuarioFK();

        #region Inicial
        public CRUDusuarios()
        {
            InitializeComponent();
            CargarCB();
        }
        #endregion

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion

        #region Cargar FK
        void CargarCB()
        {
            List<string> tipousuario = objeto_CN_TipoUsuarioFK.ListarTiposUsuario();
            for (int i = 0; i < tipousuario.Count; i++)
            {
                cbTipoUsuario.Items.Add(tipousuario[i]);
            }
        }
        #endregion

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbNombre.Text == ""
                || tbApellido.Text == ""
                || tbCel.Text == ""
                || tbCorreo.Text == ""
                || tbPais.Text == ""
                || tbRut.Text == ""
                || tbUser.Text == ""
                || cbTipoUsuario.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


        #region Estado de cuenta
        private void Habilitar_Check(object sender, RoutedEventArgs e)
        {
            string estado;
            if (chkHabilitar.IsChecked == true)
            {
                estado = "Habilitado";
            }
            else
            {
                estado = "Deshabilitado";
            }
        }

        #endregion

        #region VALIDAR RUT
        public bool ValidarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {

            }
            return validacion;

        }

        #endregion
        #region ValidarCorreo
        static bool ValidarCorreo(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        #endregion
        #region CRUD
        public int idUsuario;
        public string Patron = "Portafolio";
        #endregion
        #region CREAR
        private void Crear(object sender, RoutedEventArgs e)
        {
            //Validaciones basicas
            if (tbContrasena.Password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener mas de 6 caracteres");
                return;
            }
            else if (tbContrasena.Password == "")
            {
                MessageBox.Show("La contraseña debe tener mas de 6 caracteres");
                return;
            }
            else if (tbNombre.Text == "")
            {
                MessageBox.Show("El nombre no puede quedar vacio");
                return;
            }
            //valido que se ingresen solo letras
            else if (Regex.IsMatch(tbNombre.Text, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("El nombre solo puede contener letras");
                return;
            }
            else if (tbApellido.Text == "")
            {
                MessageBox.Show("El Apellido no puede quedar vacio");
                return;
            }
            //valido que se ingresen solo letras
            else if (Regex.IsMatch(tbApellido.Text, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("El Apellido solo puede contener letras");
                return;
            }
            else if (tbUser.Text == "")
            {
                MessageBox.Show("El usuario no puede quedar vacio");
                return;
            }
            //Correo
            else if (tbCorreo.Text == "")
            {
                MessageBox.Show("El Correo no puede quedar vacio");
                return;
            }
            else if (ValidarCorreo(tbCorreo.Text.ToString()) == false)
            {
                MessageBox.Show("Ingresar formato correo");
                return;
            }
            else if (Regex.IsMatch(tbPais.Text, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("El País solo puede contener letras");
                return;
            }
            else if (tbCel.Text.Length != 9 && Regex.IsMatch(tbCel.Text, @"^\d +$:") == false)
            {
                MessageBox.Show("Ingrese los 9 digitos de su celular");
                return;
            }
            else if (ValidarRut(tbRut.Text.ToString()) == false)
            {
                MessageBox.Show("Ingrese correctamente el rut");
                return;
            }


            if (CamposLlenos() == true)
            {
                try
                {
                    int tipousuario = objeto_CN_TipoUsuarioFK.idTipoUsuario(cbTipoUsuario.Text);

                    objeto_CE_Usuarios.Nombres = tbNombre.Text;
                    objeto_CE_Usuarios.Apellidos = tbApellido.Text;
                    objeto_CE_Usuarios.Usuario = tbUser.Text;
                    objeto_CE_Usuarios.Correo = tbCorreo.Text;
                    objeto_CE_Usuarios.Contrasena = tbContrasena.Password;
                    objeto_CE_Usuarios.Patron = Patron;
                    objeto_CE_Usuarios.Identificacion = tbRut.Text;
                    objeto_CE_Usuarios.Celular = tbCel.Text;
                    objeto_CE_Usuarios.Pais = tbPais.Text;
                    objeto_CE_Usuarios.CodigoVerificacion = " ";
                    if (chkHabilitar.IsChecked == true)
                    {
                        objeto_CE_Usuarios.Habilitada = "Habilitado";
                    }
                    else
                    {
                        objeto_CE_Usuarios.Habilitada = "Deshabilitado";
                    }
                    objeto_CE_Usuarios.EsPasaporte = " ";
                    objeto_CE_Usuarios.IdTipoUsuario = tipousuario;

                    objeto_CN_Usuarios.Insertar(objeto_CE_Usuarios);

                    Content = new Usuarios();
                }
                catch
                {
                    MessageBox.Show("Revise bien sus datos");
                }
                

            }
            else
            {
                MessageBox.Show("No se pudo ingresar usuario, porfavor revise sus datos");
            }
        }
        #endregion
        #region READ
        public void Consultar()
        {
            var a = objeto_CN_Usuarios.Consulta(idUsuario);
            tbNombre.Text = a.Nombres.ToString();
            tbApellido.Text = a.Apellidos.ToString();
            tbUser.Text = a.Usuario.ToString();
            tbCorreo.Text = a.Correo.ToString();
            tbRut.Text = a.Identificacion.ToString();
            tbCel.Text = a.Celular.ToString(); 
            tbPais.Text = a.Pais.ToString();

            var b = objeto_CN_TipoUsuarioFK.nombreTipoUsuario(a.IdTipoUsuario);
            cbTipoUsuario.Text = b.TipoUsuario;

            if (a.Habilitada == "Habilitado")
            {
                chkHabilitar.IsChecked = true;
            }
            else
            {
                chkHabilitar.IsChecked = false;
            }

        }
        #endregion
        #region UPDATE
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if(CamposLlenos() == true)
            {
                //pendiente
                int tipousuario = objeto_CN_TipoUsuarioFK.idTipoUsuario(cbTipoUsuario.Text);

                objeto_CE_Usuarios.IdUsuario = idUsuario;
                objeto_CE_Usuarios.Nombres = tbNombre.Text;
                objeto_CE_Usuarios.Apellidos = tbApellido.Text;
                objeto_CE_Usuarios.Usuario = tbUser.Text;
                objeto_CE_Usuarios.Correo = tbCorreo.Text;
                objeto_CE_Usuarios.Contrasena = tbContrasena.Password;
                objeto_CE_Usuarios.Patron = Patron;
                objeto_CE_Usuarios.Identificacion = tbRut.Text;
                objeto_CE_Usuarios.Celular = tbCel.Text;
                objeto_CE_Usuarios.Pais = tbPais.Text;
                objeto_CE_Usuarios.CodigoVerificacion = " ";
                if (chkHabilitar.IsChecked == true)
                {
                    objeto_CE_Usuarios.Habilitada = "Habilitado";
                }
                else
                {
                    objeto_CE_Usuarios.Habilitada = "Deshabilitado";
                }
                objeto_CE_Usuarios.EsPasaporte = " ";
                objeto_CE_Usuarios.IdTipoUsuario = tipousuario;

                objeto_CN_Usuarios.ActualizarDatos(objeto_CE_Usuarios);

                Content = new Usuarios();
            }
            else
            {
                MessageBox.Show("Por favor, no dejar campos vacios");
            }

            if(tbContrasena.Password.Length > 6)
            {
                objeto_CE_Usuarios.IdUsuario = idUsuario;
                objeto_CE_Usuarios.Contrasena = tbContrasena.Password;
                objeto_CE_Usuarios.Patron = Patron;

                objeto_CN_Usuarios.ActualizarPass(objeto_CE_Usuarios);
                Content = new Usuarios();
            }

        }
        #endregion
        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            objeto_CE_Usuarios.IdUsuario = idUsuario;

            objeto_CN_Usuarios.Eliminar(objeto_CE_Usuarios);

            Content = new Usuarios();
        }

        #endregion


        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            tbContrasena.Visibility = Visibility.Visible;
            txtContra.Visibility = Visibility.Visible;
            MessageBox.Show("Ingrese una contraseña de 6 caracteres");
            
        }

      
    }
}
