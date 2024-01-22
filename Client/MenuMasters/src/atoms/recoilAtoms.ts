// recoilAtoms.ts
import { atom } from "recoil";

export interface CartItemCountState {
  cartItemCount: number;
}

export const cartItemCountState = atom<CartItemCountState>({
  key: "cartItemCountState",
  default: { cartItemCount: 0 },
});
