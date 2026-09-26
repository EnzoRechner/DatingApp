import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ApiError } from '../../../types/error';

@Component({
  imports: [],
  selector: 'app-server-error',
  styleUrl: './server-error.css',
  templateUrl: './server-error.html',
})
export class ServerError {
  protected error: ApiError;
  // helper function for router navigation
  private router = inject(Router);
  protected showDetails = false;

  constructor() {
    // get current navigation is disabled
    const navigation = this.router.currentNavigation();
    this.error = navigation?.extras?.state?.['error'];
  }

  detailToggle() {
    this.showDetails = !this.showDetails;
  }
}
