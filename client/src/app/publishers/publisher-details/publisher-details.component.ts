import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPublisher } from 'src/app/shared/models/publisher';
import { PublishersService } from '../publishers.service';

@Component({
  selector: 'app-publisher-details',
  templateUrl: './publisher-details.component.html',
  styleUrls: ['./publisher-details.component.css'],
})
export class PublisherDetailsComponent implements OnInit {
  publisher: IPublisher;

  constructor(
    private adminService: PublishersService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadPublisher();
  }

  loadPublisher(): void {
    this.adminService
      .getPublisher(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (publisher) => {
          this.publisher = publisher;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
