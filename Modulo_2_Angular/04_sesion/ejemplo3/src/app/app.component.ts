import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CardComponent } from "./components/card/card.component";
import { TarjetaComponent } from "./components/tarjeta/tarjeta.component";
import { CommonModule } from '@angular/common';
import { TodoComponent } from "./components/todo/todo.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CardComponent, TarjetaComponent, CommonModule, TodoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ejemplo3';

  isVisible = true;
  frutas = ["Manzana", "Platano", "Naranja", "Uva", "Piña"];
}
