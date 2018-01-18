<?php

	header("Content-disposition: attachment; filename=Clase_Moda.cs"); //nombre del archivo a descargar
	header("Content-type: application/octet-stream"); //MIME - Extensiones multiproposito de correo en internet
	readfile("Clase_Moda.cs"); //archivo para descargar

//https://mimentevuela.wordpress.com/2015/01/20/descarga-de-archivos-con-php/
?>

