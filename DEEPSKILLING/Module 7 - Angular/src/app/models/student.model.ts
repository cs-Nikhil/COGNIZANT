export interface Student {
  id: number;
  name: string;
  email: string;
  batch: string;
  role: 'Student' | 'Mentor';
  city: string;
  bio: string;
}

