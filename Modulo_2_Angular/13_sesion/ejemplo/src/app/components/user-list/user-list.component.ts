import { CommonModule } from '@angular/common';
import { UserService } from './../../service/user.service';
import { Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-user-list',
  imports: [CommonModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  users: any[] = [];

  @Output() selectUser = new EventEmitter();

  constructor(private userService: UserService){}

  ngOnInit(){
    this.userService.getUsers().subscribe(res => this.users = res.results);
    console.log(this.users);
  }

}
