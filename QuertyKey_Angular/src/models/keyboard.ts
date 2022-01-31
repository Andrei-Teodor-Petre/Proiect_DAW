import { Keycap } from "./Keycap";
import { Switch } from "./Switch";

export class Keyboard{
  id: string;
  name: string;
  description: string;
  addedOn: Date;
  quantity: number;
  price:number;
  isHotswap: boolean;
  size: string;
  switch: Switch;
  keycap: Keycap;
}
