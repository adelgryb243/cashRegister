using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

    //cleaner = burger
    //guard = fry
    //assistant = drink

//Adele Gryba
//Cash Register Summative
//feb  19th
//Mr T.

namespace cashRegister
{
  //fix decimals in given change
  //fix the box empty pppl only wannna get one borgar or drank sometimes 
  //why do sound wav names need to all be diff?
  //keeping label orginized and straight
    public partial class Form1 : Form
    {
       //declaring fixed prices and tax percentage 
        const double burgerPrice = 10;
        const double fryPrice = 5;
        const double drinkPrice =2;
        const double tax = 0.13;

        //declaring variables for textboxes to hold given info in
        double burger;
        double fry;
        double drink;
        //variables for holding the total for items and their cost including change tax and total
        double total;
        double fullTotal;
        double givenAmount;
        double change;
        double totalTax;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //save the info typed in textboxes to assigned variables
                burger = Convert.ToInt16(textBox1.Text);
                fry = Convert.ToInt16(textBox2.Text);
                drink = Convert.ToInt16(textBox3.Text);

                //calculate total
                total = (burgerPrice * burger) + (drinkPrice * drink) + (fryPrice * fry);

                //calculate tax
                totalTax = tax * total;

                //calculate total
                fullTotal = totalTax + total;

                //display subtotal recipt
                totalLabel.Text = "Subtotal:  " + total.ToString("$#.00");
                totalLabel.Text += "\nTax:    " + totalTax.ToString("$#.00");
                totalLabel.Text += "\nTotal:   " + fullTotal.ToString("$#.00");

            }
            catch
            {
                //so program doesnt crash when huge numbers/letters/whatever is typed in
                totalLabel.Text = "DO not waste our time. Insert a valid number";
            }
            
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                givenAmount = Convert.ToInt32(textBox4.Text);

                //display change for order
                change = givenAmount - fullTotal;

                //display change subtotal
                changeLabel.Text = "Change:   " + change.ToString("$#.00");

                if (givenAmount < fullTotal)
                {
                    changeLabel.Text = "You do not have enough money. Leave.";
                    //if someone doesnt have enouygh to pay, enters a number too small
                }


            }
            catch
            {
                changeLabel.Text = "Do not waste our time. Insert a valid number.";
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //print recipt
            //for every line alternate between printing sounds

            reciptLabel.Text = "\n\n        Droid-Mart        ";
            SoundPlayer print = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += DateTime.Now.ToString();
            SoundPlayer print1 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n\n Cleaners:      x" + burger + "     @" + burgerPrice.ToString("$#.00");
            SoundPlayer brint1 = new SoundPlayer(Properties.Resources.printSound2);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n Guards:      x" + fry + "      @" + fryPrice.ToString("$#.00");
            SoundPlayer print2 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n Assistants:        x" + drink + "     @" + drinkPrice.ToString("$#.00") ;
            SoundPlayer print6 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n\n Subtotal:        " + total.ToString("$#.00");
            SoundPlayer brint7 = new SoundPlayer(Properties.Resources.printSound2);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n Tax:           " + totalTax.ToString("$#.00");
            SoundPlayer print18 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n Total:          " + fullTotal.ToString("$#.00");
            SoundPlayer brint19 = new SoundPlayer(Properties.Resources.printSound2);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n\n Tendered:      " + givenAmount.ToString("$#.00");
            SoundPlayer print72 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n Change:          " + change.ToString("$#.00");
            SoundPlayer brin019 = new SoundPlayer(Properties.Resources.printSound2);
            print.Play();

            Refresh();
            Thread.Sleep(1000);

            reciptLabel.Text += "\n\n We thank you for your purchase!";
            SoundPlayer printl72 = new SoundPlayer(Properties.Resources.printSound1);
            print.Play();

            Refresh();
            Thread.Sleep(1000);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //new order
            //Clear text boxes and labels
            //set all variables to 0 again, except for fixed prices
           
            reciptLabel.Text = "";
            changeLabel.Text = "";
            totalLabel.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            totalTax = 0;
            burger = 0;
            fry = 0;
            drink = 0;
            total = 0;
            fullTotal = 0;
            givenAmount = 0;
            change = 0;
        }


    }
}
