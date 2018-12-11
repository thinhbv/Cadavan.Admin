using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Utils;
using Libs.Db;

public partial class Encrypt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btMD5_Click(object sender, EventArgs e)
    {
        txtResult.Text = Encrypts.MD5(txtData.Text.Trim());
    }

    protected void btEcrypt_Click(object sender, EventArgs e)
    {
        RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(txtKey.Text, "@1B2c3D4e5F6g7H8");
        txtResult.Text = rijndaelKey.Encrypt(txtData.Text);
    }

    protected void btDeEncrypt_Click(object sender, EventArgs e)
    {
        RijndaelEnhanced rijndaelKey = new RijndaelEnhanced(txtKey.Text, "@1B2c3D4e5F6g7H8");
        txtResult.Text = rijndaelKey.Decrypt(txtData.Text);
    }
}