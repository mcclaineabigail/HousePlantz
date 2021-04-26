import { Component } from '@angular/core';

@Component({
  selector: 'hp-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  pageTitle = 'House Plant Catalog';
  isDarkTheme: boolean = false;

  ngOnInit() {
    this.isDarkTheme = localStorage.getItem('theme') === "Dark" ? true:false;
  }
  storeThemeSelection() {
    localStorage.setItem('theme', this.isDarkTheme ? "Dark" : "Light");
  }
}
