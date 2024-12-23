import { AxiosResponse } from "axios";
import { $auth_api } from "../http/index";
import User from "../Models/User";

export default class AuthService
{
    static async signIn(id : string | null) : Promise<AxiosResponse<User>>
    {
        return await $auth_api.post<User>("/sign-in", {id});
    }

    static async signUp() : Promise<AxiosResponse<User>>
    {
        return await $auth_api.post<User>("/sign-up");
    }
}