import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { Login } from '../../interfaces/user/Login';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss',
})
export class UserComponent {
  loginForm!: FormGroup;
  loading = false;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  Save(): void {
    this.errorMessage = null;
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.loading = true;
    const payload : Login = { ...this.loginForm.value };

    this.userService.login(payload).subscribe({
      next: (session) => {
        localStorage.setItem('token', session.token);
        localStorage.setItem('email', session.email);
        localStorage.setItem('password', session.password);

        this.loginForm.reset();
        this.router.navigate(['/product']);
      },
      error: (err) => {
        this.errorMessage =
          typeof err === 'string'
            ? err
            : err?.error ?? err?.message ?? 'Error al iniciar sesión';
        this.loading = false;
      },
      complete: () => (this.loading = false),
    });
  }
}
