import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-perfil',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {

  public titulo = 'Perfil';

  constructor() { }

  ngOnInit(): void {
  }

}
