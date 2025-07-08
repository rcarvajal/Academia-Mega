import { Component, NgModule  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ItemListComponent } from "./components/item-list/item-list.component";

@Component({
  selector: 'app-root',
  imports: [ItemListComponent, CommonModule, BrowserModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
