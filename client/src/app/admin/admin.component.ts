import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IDictionary } from '../shared/models/dictionary';
import { IPublisher } from '../shared/models/publisher';
import { PublisherParams } from '../shared/models/publisherParams';
import { AdminService } from './admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  publishers: IPublisher[];
  statuses: IDictionary[];
  groups: IDictionary[];
  titles: IDictionary[];
  publisherParams = new PublisherParams();
  totalCount: number;
  sortOptions = [
    { name: 'last name asc', value: 'lastNameAsc' },
    { name: 'last name desc', value: 'lastNameDesc' },
    { name: 'group asc', value: 'groupAsc' },
    { name: 'group desc', value: 'groupDesc' },
    { name: 'status asc', value: 'statusAsc' },
    { name: 'status desc', value: 'statusDesc' },
  ];

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.getPublishers();
    this.getGroups();
    this.getStatuses();
    this.getTitles();
  }

  getPublishers(): void {
    this.adminService.getPublishers(this.publisherParams).subscribe(
      (response) => {
        this.publishers = response.data;
        this.totalCount = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getStatuses(): void {
    this.adminService.getStatuses().subscribe(
      (response) => {
        this.statuses = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getGroups(): void {
    this.adminService.getGroups().subscribe(
      (response) => {
        this.groups = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getTitles(): void {
    this.adminService.getTitles().subscribe(
      (response) => {
        this.titles = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onGroupSelected(groupId: number): void {
    this.publisherParams.groupId = groupId;
    this.publisherParams.pageNumber = 1;
    this.getPublishers();
  }

  onTitleSelected(titleId: number): void {
    this.publisherParams.titleId = titleId;
    this.publisherParams.pageNumber = 1;
    this.getPublishers();
  }

  onStatusSelected(statusId: number): void {
    this.publisherParams.statusId = statusId;
    this.publisherParams.pageNumber = 1;
    this.getPublishers();
  }

  onSortSelected(sort: string): void {
    this.publisherParams.sort = sort;
    this.getPublishers();
  }

  onPageChanged(event: any): void {
    if (this.publisherParams.pageNumber !== event) {
      this.publisherParams.pageNumber = event;
      this.getPublishers();
    }
  }

  onSearch(): void {
    this.publisherParams.search = this.searchTerm.nativeElement.value;
    this.publisherParams.pageNumber = 1;
    this.getPublishers();
  }

  onReset(): void {
    this.searchTerm.nativeElement.value = '';
    this.publisherParams = new PublisherParams();
    this.getPublishers();
  }
}
