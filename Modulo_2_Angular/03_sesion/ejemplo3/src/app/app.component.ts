import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CardComponent } from "./components/card/card.component";
import { TarjetaComponent } from "./components/tarjeta/tarjeta.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CardComponent, TarjetaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ejemplo3';
}
