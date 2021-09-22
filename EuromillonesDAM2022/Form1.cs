using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuromillonesDAM2022
{
    public partial class FormPrincipal : Form
    {
        static ArrayList arrayReps = new ArrayList();
        static int[] arrayUsuario = new int[6];
        static int[] arrayResultado = new int[6];
        static int[] arrayAciertos = new int[6];
        static Random aleatorio = new Random();
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void limpiar() {
            foreach (Control ctrl in groupBox1.Controls)
            {
                ctrl.ResetText();
            }
        }

        


        private void FormPrincipal_Paint(object sender, PaintEventArgs e)
        {
        }

        /*
        private void KeyPressParaValidar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.Text.Equals(""))
                {
                    MessageBox.Show("Introduce un número");
                }
                else
                {
                    int num = Convert.ToInt16(textBox.Text);
                    if (!validar(num))
                    {
                        MessageBox.Show("Introduce solo números del 0 al 50");
                        textBox.Clear();
                    }
                    else
                    {
                        if (!validarRep(num))
                        {
                            MessageBox.Show("Ya has introducido ese número");
                            textBox.Clear();
                        }
                        else
                        {
                            arrayReps.Add(num);
                            textBox.Enabled = false;
                        }
                    }
                }


            
            }
        }
        */


        private bool validar(int num)
        {
            if (num <= 50 && num > 0)
            {
                return true;
            }
            else return false;

        }

        private bool validarRep(int num)
        {
            if (arrayReps.Contains(num))
            {
                return false;
            }
            else return true;
        }

        private void KeyPressParaValidar(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.Text.Equals(""))
                {
                    MessageBox.Show("Introduce un número");
                }
                else
                {
                    int num = 0;
                    try
                    {
                        num = Convert.ToInt16(textBox.Text);                   

                    if (!validar(num))
                    {
                        MessageBox.Show("Introduce solo números del 0 al 50");
                        textBox.Clear();
                    }
                    else
                    {
                        if (!validarRep(num))
                        {
                            MessageBox.Show("Ya has introducido ese número");
                            textBox.Clear();
                        }
                        else
                        {
                            arrayReps.Add(num);
                            textBox.Enabled = false;
                        }
                    }

                    }

                    catch (System.FormatException)
                    {
                        MessageBox.Show("Introduce solo números");
                        textBox.Clear();
                    }
                }


                int contador = 0;
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl.Enabled == false) contador++;
                }
                if (contador == 6){
                    button1.Enabled = true;                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            int i = 0;
            foreach (Control ctrl in groupBox1.Controls)
            {
                arrayUsuario[i] = Convert.ToInt16(ctrl.Text);
                i++;
            }
            arrayResultado =llenarArray();
            i = 0;
            foreach (Control ctrl in groupBox2.Controls)
            {
                ctrl.Text= arrayResultado[i].ToString();

                i++;
            }

            for (int j = 0; j < 6; j++) {
                if (arrayUsuario[j] == arrayResultado[j])
                {
                    arrayAciertos[j] = arrayUsuario[j];
                }
                else arrayAciertos[j] = -1;
            }

            i = 0;
            foreach (Control ctrl in groupBox3.Controls)
            {
                ctrl.Text = arrayAciertos[i].ToString();

                i++;
            }

        }

        //MÉTODO PARA GENERAR LOS ALEATORIOS Y METERLOS EN UN ARRAY
        private int[] llenarArray()
        {
            int[] array = new int[6];
            int num;
            int[] arrayTemp = new int[6];
            for (int i = 0; i < array.Length; i++){
                do{
                    num = aleatorio.Next(0, 50);
                }
                while (array.Contains(num));
                array[i] = num;
            }
            return array;

        }

        private void reset() {
            arrayReps.Clear();
            button1.Enabled = false;
            foreach (Control ctrl in groupBox1.Controls) {
                ctrl.ResetText();
                ctrl.Enabled = true;
            }
            textBoxNumero1.Focus();
            foreach (Control ctrl in groupBox2.Controls)
            {
                ctrl.ResetText();
            }
            foreach (Control ctrl in groupBox3.Controls)
            {
                ctrl.ResetText();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
