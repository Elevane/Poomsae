import { atom } from "recoil";

const userSportsState = atom<[]>({
    key: 'userSportsState',
    default: [], 
  });

  export default userSportsState;