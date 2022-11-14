export interface Employee {
  id: number;
  name: string;
  age: number;
  addressId: number;
  positionId: number;
  signingTimeUtc: Date;
  leavingTimeUtc: Date;
  isActive: boolean;
}
