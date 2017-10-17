using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CRUD_EditSalesAreas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        // Here is where I can inspect the event t see if an exception has occurred
        if(e.Exception is DbEntityValidationException)
        {
            var ex = e.Exception as DbEntityValidationException;
            var details = from DbValidationError error
                          in ex.EntityValidationErrors.First().ValidationErrors
                          select error.ErrorMessage;
            MessageLabel.Text = "The following validation errors occurred: "
                                    + "<blockquote><ul>";
            foreach (string problem in details)
                MessageLabel.Text += $"<li>{problem}</li>";
            MessageLabel.Text += "<ul><blockquote>";
        }
    }
}