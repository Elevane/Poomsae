import React, { useState } from "react";
import { Form } from "antd"
import { useForm } from "antd/es/form/Form";
import SubmitButton from "../../Molecules/SubmitButton";
import { ResetPasswordRequest } from "../../../Models/apiModels";
import useUserService from "../../../Hooks/Services/UseUserService";
import PasswordFormItem from "./FormInputs/PasswordFormItem";
import ConfirmEmailFormItem from "./FormInputs/ConfirmEmailFormItem";

export interface resetPasswordProps {
    loading: boolean,
}

const ResetPasswordForm: React.FC = () => {
    const [form] = useForm<ResetPasswordRequest>()
    const [loading, setLoading] = useState<boolean>(false)
    const authService = useUserService()

    const handleSubmit = async (resetPasswordInputs: ResetPasswordRequest) => {
        setLoading(true)
        await authService.resetPassword(resetPasswordInputs)
        setLoading(false)
    }
    return (<Form form={form} onFinish={handleSubmit} >
        <PasswordFormItem label="Current Password" />
        <PasswordFormItem label="New Password" name="newPassword" />
        <ConfirmEmailFormItem label="Confirm new Password" reference="newPassword" />
        <SubmitButton loading={loading} text={"Change Password"} />
    </Form>)
}

export default ResetPasswordForm