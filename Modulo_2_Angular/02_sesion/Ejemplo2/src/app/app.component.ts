import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Compenent1Component } from "./components/compenent-1/compenent-1.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Compenent1Component],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Ejemplo2';
}
