import { atom } from "recoil";
import { ParentEntity } from "../Models/SportsModels";

const userSportsState = atom<ParentEntity[]>({
  key: 'userSportsState',
  default: [],
});

export default userSportsState;