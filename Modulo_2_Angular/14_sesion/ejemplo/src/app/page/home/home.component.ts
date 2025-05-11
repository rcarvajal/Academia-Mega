import { Component } from '@angular/core';
import { HijoComponent } from "../../components/hijo/hijo.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [HijoComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  usuarios = [
    {nombre: "Juan", edad: 10, profesion:"Ingeniero"},
    {nombre: "Miguel", edad: 25, profesion:"Dr."},
    {nombre: "Arturo", edad: 100, profesion:"Carpintero"},
    {nombre: "CaraLampio", edad: 50, profesion:"TI"},
  ]


  mensajeDelHijo: string = "";

  recibirMensaje(mensaje: string){
      this.mensajeDelHijo = mensaje;
  }

}
