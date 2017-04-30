using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // List<ContactS> aContact = new List<ContactS>();
        private ContactS[] aContact = new ContactS[100];
       

        private void Form1_Load(object sender, EventArgs e)
        {
            ///folder needs to be located in desktop
            string path = @"\Desktop\AddressBookEmma\AddressBook\addresses.txt";
            ///If file is in c:drive
            //string path = @"C\addresses.txt";
            StreamReader reader = new StreamReader(path);
            int index = 0;
            
            try { 

            for(string str = reader.ReadLine(); str != null; str = reader.ReadLine())
            {
                string item = reader.ReadLine();
                comboBox1.Items.Add(item);
                aContact[index] = new ContactS(str, item);
                aContact[index].Address = reader.ReadLine();
                aContact[index].City = reader.ReadLine();
                aContact[index].State = reader.ReadLine();
                aContact[index].Zip = reader.ReadLine();
                aContact[index].Phone = reader.ReadLine();
                aContact[index].Email = reader.ReadLine();
                index++;
            }
           }
            catch { }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = 0;
            string str2 = comboBox1.SelectedItem.ToString();
            try
            {
                while (str2 != aContact[index].LastName)
                {
                    index++;
                }

                string lastName = aContact[index].LastName;
                string firstName = aContact[index].FirstName;
                textBox1.Text = firstName + "" + lastName;
              
                textBox2.Text = aContact[index].Address;
                textBox3.Text = aContact[index].City;
                textBox4.Text = aContact[index].State;
                textBox5.Text = aContact[index].Zip;
                textBox6.Text = aContact[index].Phone;
                textBox7.Text = aContact[index].Email;
                Visibility(true);
            }
            catch { }

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visibility(false);
            comboBox1.Text = "";
        }

        public void Visibility(bool newState)
        {

            textBox1.Visible = newState;
            textBox2.Visible = newState;
            textBox3.Visible = newState;
            textBox4.Visible = newState;
            textBox5.Visible = newState;
            textBox6.Visible = newState;
            textBox7.Visible = newState;
            label1.Visible = newState;
            label2.Visible = newState;
            label3.Visible = newState;
            label4.Visible = newState;
            label5.Visible = newState;
            label6.Visible = newState;
            label7.Visible = newState;

            if (newState)
            {
               this.pictureBox1.Visible = false;

            }
            else
            {
              this. pictureBox1.Visible = true;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name:\tEmmanuel\nCourse:\tIDTEV 11\nInstructor:\tJudy\nAssignmnet:#9");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

class ContactS
{
    private string address;
    private string city;
    private string email;
    private string firstName;
    private string lastName;
    private string phone;
    private string zip;
    private string state;

    public ContactS( string contactFirstName, string contactLastName)
    {
     
        this.firstName = contactFirstName;
        this.lastName = contactLastName;
    }

    public override string ToString()
    {
        return lastName;
    }


    public string FirstName
    {
        get
        {
            return firstName;
        }
    
   }

    public string LastName
    {
        get
        {
            return lastName;
        }
    }
    public string Address
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    public string City
    {
        get
        {
            return city;
        }
        set
        {
            city = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }
    public string Zip
    {
        get
        {
            return zip;
        }
        set
        {
            zip = value;
        }
    }
    public string Phone
    {
        get
        {
            return phone;
        }
        set
        {
            phone = value;
        }
    }
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }
}
