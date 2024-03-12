import { Component } from '@angular/core';
import { GalleryComponent } from "../gallery/gallery.component";
import { HomecardsComponent } from "../homecards/homecards.component";

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [GalleryComponent, HomecardsComponent]
})
export class HomeComponent {
  description_title = 'DESCRIPCIÓN';
  description = '... breve descripción del proyecto ...';

}
