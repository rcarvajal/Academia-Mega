import { Component, OnInit } from '@angular/core';
import { ItemService, Item } from '../../services/item.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  imports: [CommonModule, BrowserModule, FormsModule],
  selector: 'app-item-list', templateUrl: './item-list.component.html' })
export class ItemListComponent implements OnInit {
  items: Item[] = [];
  newItem: Item = { name: '', price: 0 };

  constructor(private itemSvc: ItemService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.itemSvc.getAll().subscribe(data => this.items = data);
  }

  add() {
    this.itemSvc.create(this.newItem).subscribe(() => {
      this.newItem = { name: '', price: 0 };
      this.load();
    });
  }
}
