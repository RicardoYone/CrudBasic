import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { Login } from '../interfaces/user/Login';
import { SessionDto } from '../interfaces/user/SessionDto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = `${environment.apiUrl}/authentication`;

  constructor(private http: HttpClient) {}

  login(login: Login): Observable<SessionDto> {
    return this.http.post<SessionDto>(`${this.apiUrl}/Login`, login);
  }
}
