using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace joincrud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MCA\MCA_2\BD.net\joincrud\joincrud\joincrud\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            FilldName();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "insert into Orders Values(@custid,@orderdate,@shipdate,@orderamt,@paymentmode,@remarks)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@custid", ddcustid.SelectedValue);
            cmd.Parameters.AddWithValue("@orderdate", txtorderdate.Text);
            cmd.Parameters.AddWithValue("@shipdate", txtshipdate.Text);
            cmd.Parameters.AddWithValue("@orderamt", txtamt.Text);
            cmd.Parameters.AddWithValue("@paymentmode", ddpayment.SelectedValue); 
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('insert successfully....')</script>");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "update Orders set custid=@custid,orderdate=@orderdate,shipdate=@shipdate,orderamt=@orderamt,paymentmode=@paymentmode,remarks=@remarks where  orderid=@orderid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@custid", ddcustid.SelectedValue);
            cmd.Parameters.AddWithValue("@orderdate", txtorderdate.Text);
            cmd.Parameters.AddWithValue("@shipdate", txtshipdate.Text);
            cmd.Parameters.AddWithValue("@orderamt", txtamt.Text);
            cmd.Parameters.AddWithValue("@paymentmode", ddpayment.SelectedValue);
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text);
            cmd.Parameters.AddWithValue("@orderid", txtorderid.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('update successfully....')</script>");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "delete from Orders where orderid=@orderid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", txtorderid.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Record Deleted.....')</script>");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from Orders where orderid='"+txtorderid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                ddcustid.SelectedValue = dr["custid"].ToString();
                txtorderdate.Text = dr["orderdate"].ToString();
                txtshipdate.Text = dr["shipdate"].ToString();
                txtamt.Text = dr["orderamt"].ToString();
                ddpayment.SelectedValue = dr["paymentmode"].ToString();
                txtremarks.Text = dr["remarks"].ToString();
            }
            con.Close();
        }
        public void FilldName()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select custid from Customer";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ddcustid.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select o.orderid,o.custid,c.name,c.city,c.state,o.orderamt from Customer c,Orders o where c.custid=o.custid";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if(ddsearch.SelectedValue=="Q1")
            {
                //Display all orders with orderid, custid, customer name, city, state, order amount.
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select o.orderid,o.custid,c.name,c.city,c.state,o.orderamt from Customer c,Orders o where c.custid=o.custid ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();

            }
            else if(ddsearch.SelectedValue=="Q2")
            {
                //) Display all orders with OrderID, CustID, customer name, city, state with order amount greater than 10000.
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select o.orderid,o.custid,c.name,c.city,c.state,o.orderamt from Customer c,Orders o where c.custid=o.custid and o.orderamt>11000";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Q3")
            {
                //Display customer details with total order amount
                SqlConnection con = new SqlConnection(str);
                con.Close();
                string query = "select sum(o.orderamt) from Orders o GROUP BY o.custid";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();

            }
            else if(ddsearch.SelectedValue=="Q4")
            {
                //Display CustID, name, OrderAmount by Month and Year
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select * from Customer c,Orders o where c.custid=o.custid ORDER BY YEAR(o.orderdate),MONTH(o.orderdate) ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Q5")
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select paymentmode,SUM(orderamt) from Orders GROUP BY paymentmode";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Q6")
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select Orders.orderid,Customer.name from Orders INNER JOIN Customer ON Orders.custid=Customer.custid ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Q7")
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string query = "select Customer.name,Orders.orderid from Customer left join Orders on Customer.custid=Orders.custid order by Customer.name";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }

        }
    }
}