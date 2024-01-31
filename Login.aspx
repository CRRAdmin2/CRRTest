<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      body
      {
				  background-color: #eeeeee;
          height: 100%;
      	}
      #contenedor
      {
      	 position:fixed; 
         top:50%; 
         left:50%; 
         margin: -90px auto auto -194px; 

      }
      .login
      {
      	background-image: url(Images/crr-login.png);
        BACKGROUND-REPEAT: no-repeat;
        height:183px;
        width:386px;	
      }
      .cajaTitulo
      {
      	padding: 0 0 0 0;
      	background-color: White;
        color: Black;
      	font-weight: bold;
      	height: 30px;
      }
      .cajaTitulo TD
      {
      	padding-bottom: 3px;
      	padding-top: 3px;
      }
      .cajaIzq
      {
      	 background-image: url(Imagen/fondo-caja-roja-izq.gif);
      	 background-repeat: no-repeat;
      	 padding-left: 10px;
      	 padding-right: 0px;
      	}
      .cajaDer
      {
      	 background-image: url(Imagen/fondo-caja-roja-der.gif);
      	 background-position:right;
      	 background-repeat:no-repeat; 
      	 padding-left: 5px;
      	 padding-right: 9px;
      	}
      .cajaTexto
      {
      	border-style: none;
      	border-color: White;
      	}
      .BotonEntrarEspacio
      {
        padding-right: 75px;	
      }
      .boton
      {
      	color: White;
      	background-color: navy;
      	}
      .desactivado
      {
        BACKGROUND-IMAGE: url(Imagen/fondo-login.gif); 
        BACKGROUND-REPEAT: no-repeat;
        height: 183px;
        width: 386px;
        color: White;
      	font-weight: bold;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  id="contenedor">
    <asp:panel ID="panelLogin" runat="server">
      <table class="login" cellspacing="0" cellpadding="0" border="0">
	      <tr>
		      <td><table cellpadding="0" border="0" style="height:150px;width:386px;">
			      <tr>
				      <td align="center" height="10px"></td>
			      </tr><tr>
				      <td align="center">
				        <table cellpadding="0" cellspacing="0" border="0" class="cajaTitulo">
	                <tr>
		                <td align="right" class="cajaIzq"><label>User:</label>
				            </td>
			              <td class="cajaDer">
                      <asp:TextBox ID="txtUsuario" runat="server" CssClass="cajaTexto" 
                        Width="170px"></asp:TextBox>
				            </td>
				          </tr>
				        </table>
				      </td>
			      </tr><tr>
				      <td align="center">
				        <table cellpadding="0" cellspacing="0" border="0" class="cajaTitulo">
	                <tr>
		                <td align="right" class="cajaIzq"><label>Password:</label>
				            </td>
			              <td class="cajaDer">
                      <asp:TextBox ID="txtContrasena" runat="server" CssClass="cajaTexto" 
                        TextMode="Password"></asp:TextBox>
				            </td>
				          </tr>
				        </table>
				      
				      </td>
			      </tr><tr>
				      <td align="right" class="BotonEntrarEspacio">
                <asp:Button ID="btnEntrar" runat="server" Text="Login" CssClass="boton" />
              </td>
			      </tr>
		      </table></td>
	      </tr>
      </table>
    </asp:panel>
    </div>
    </form>
</body>
</html>
