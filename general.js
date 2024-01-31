function Pop_Calendar(obje) {
  var Xp = window.event.screenX - 135;
  var Yp = window.event.screenY - 90;
  var calendar_window = new Object();
  if (navigator.appName == "Microsoft Internet Explorer") {
    calendar_window = showModalDialog('ical.aspx?object=' + obje.id, 'calendar_window', "resizable:yes;help:no;status:no;scroll:no;dialogWidth:100px;dialogHeight:180px;dialogLeft:" + Xp + ";dialogTop:" + Yp + ";edge:sunken;unadorned:yes;");
    if (calendar_window != undefined) document.getElementById(obje.id.replace("hypFecha", "txtFecha")).value = calendar_window;
    //calendar_window.win = window.open('cal.aspx?object=' + obj.Id, 'calendar_window', 'width=273,height=183,top=270,left=350');
  }
  else
    calendar_window.win = window.open('ical.aspx?object=' + obje.id, 'calendar_window', 'width=273,height=183,top=' + Xp + ',left=' + Yp + ',modal=yes');
  //calendar_window.win.focus();
}

function NtsEd(id) {
  var e = window.event;

  if (e.clientX > 25) { 
    if (navigator.appName == "Netscape") {
      x = window.open('NtsEdInter.aspx?Id=' + id, 'NtsEdInter', 'top=100,left=100,width=850,height=600,modal=1,resizable=no');
      x.focus();
      if (x == 1) {
        document.getElementById("flag").value = "YES"
        document.forms[0].submit();
      }
    }
    else if (navigator.appName.indexOf("Explorer") != -1) {
    var x = window.showModalDialog('NtsEdInter.aspx?Id=' + id, 'NtsEdInter', 'dialogTop:100px;dialogLeft:100px;dialogWidth:850px;dialogHeight:600px;menubar:no;location:no;status:yes;help:no;border:thick;statusbar:1;scroll:0;resizable:0;');
      if (x == 1) {
        document.getElementById("flag").value = "YES"
        document.forms[0].submit();
      }
    }
  }
}

function NodEd(id) {
  var e = window.event;

  if (e.clientX > 25) {
    if (navigator.appName == "Netscape") {
      x = window.open('NodEdInter.aspx?Id=' + id, 'NodEdInter', 'top=100,left=100,width=850,height=600,modal=1,resizable=no');
      x.focus();
      if (x == 1) {
        document.getElementById("flag").value = "YES"
        document.forms[0].submit();
      }
    }
    else if (navigator.appName.indexOf("Explorer") != -1) {
    var x = window.showModalDialog('NodEdInter.aspx?Id=' + id, 'NodEdInter', 'dialogTop:100px;dialogLeft:100px;dialogWidth:850px;dialogHeight:600px;menubar:no;location:no;status:yes;help:no;border:thick;statusbar:1;scroll:0;resizable:0;');
      if (x == 1) {
        document.getElementById("flag").value = "YES"
        document.forms[0].submit();
      }
    }
  }
}

function DivSize() {
  var div = document.getElementById("divGridPrincipal");
  if (div != null) 
    div.style.width = document.body.clientWidth + "px";
}

function calculaTotal(t, h, tt) {
  var txt = document.getElementById(t);
  var hdn = document.getElementById(h);
  var total = document.getElementById(tt);
  if (txt.value.length == 0) txt.value = 0.0;
  if (hdn.value.length == 0) hdn.value = 0.0;
  if (total.value.length == 0) total.value = 0.0;
  limpiar(txt);
  limpiar(hdn);
  limpiar(total);

  var amort = parseFloat(txt.value);
  var amortA = parseFloat(hdn.value);
  var amortT = parseFloat(total.value);

  amortT = amortT - amortA + amort;
  total.value = amortT;
  hdn.value = amort.toFixed(2);
  moneda(total);
  //if (amort == 0)
}
function miles(txt) {
  limpiar(txt);
  txt.value = milesVal(txt.value);
}
function milesVal(txtValor) {

  var cantidad = parseFloat(txtValor).toFixed(2);
  if (cantidad == "NaN") cantidad = 0;
  if (cantidad == 0) txtValor = "0.00";
  else {
    var entero = "", deci = "", punto = "";
    var cantArreglo = cantidad.split(".");
    var aux = "";
    var len = len2 = 0;
    var i;

    entero = cantArreglo[0];
    if (cantArreglo.length >= 2) {
      punto = ".";
      for (i = 1; i < cantArreglo.length; i++)
        deci += cantArreglo[i];
    }
    if (entero.length > 3) {
      len = entero.length;
      for (j = 0, i = len - 1; i >= 0; i--) {
        if (j == 3) {
          aux += ",";
          j = 0;
        }
        aux += entero.charAt(i);
        j++;
      }
      txtValor = '';
      len = aux.length;
      for (i = len - 1; i >= 0; i--)
        txtValor += aux.charAt(i);
    }
    else txtValor = entero;
    if (punto != "") txtValor += punto + deci;
  }
  return txtValor;
}
function monedaVal(txtValor) {
  var valor = milesVal(txtValor);
  if (valor.indexOf('$') == -1)
    valor = valor = "$" + valor;
  return valor;
}
function moneda(txt) {
  miles(txt);
  if (txt.value.indexOf('$') == -1)
    txt.value = txt.value = "$" + txt.value;
}
function currencyFormat(fld, e) {
  var milSep = ',';
  var decSep = '.';
  var sep = 0;
  var key = '';
  var i = j = 0;
  var len = len2 = 0;
  var strCheck = '0123456789.';
  var aux = aux2 = '';
  var whichCode = e.keyCode; //(window.Event) ? e.which : 

  if (whichCode == 13) return true; // Enter
  if (whichCode == 8) return true; // Delete
  key = String.fromCharCode(whichCode); // Get key value from key code
  if (strCheck.indexOf(key) == -1) return false; // Not a valid key

  return true;
}

function limpiar(txt) {
  txt.value = txt.value.replace("$", "")
  txt.value = txt.value.replace("%", "")
  while (txt.value.indexOf(',') > -1) txt.value = txt.value.replace(",", "");
}

function limpiarVal(valor) {
  valor = valor.replace("$", "")
  valor = valor.replace("%", "")
  while (valor.indexOf(',') > -1) valor = valor.replace(",", "");

  return valor;
}