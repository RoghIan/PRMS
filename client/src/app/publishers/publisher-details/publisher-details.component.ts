import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPublisher } from 'src/app/shared/models/publisher';
import { BreadcrumbService } from 'xng-breadcrumb';
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
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService
  ) {
    this.bcService.set('@publisherDetails', '');
  }

  ngOnInit(): void {
    this.loadPublisher();
  }

  loadPublisher(): void {
    this.adminService
      .getPublisher(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (publisher) => {
          this.publisher = publisher;
          this.bcService.set(
            '@publisherDetails',
            `${publisher.lastName} ${publisher.firstName}`
          );
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
