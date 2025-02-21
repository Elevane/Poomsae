import React, { useState } from "react"
import { Flex, Form, Modal, Typography } from "antd"
import { DeleteOutlined } from "@ant-design/icons";
import Paragraph from "antd/es/typography/Paragraph";
import { useRecoilState } from "recoil";
import useUserService from "../../../Hooks/Services/UseUserService";
import { authState } from "../../../state/auth";
import SubmitButton from "../../Molecules/SubmitButton";
import { Content } from "antd/es/layout/layout";

const DeleteAccountForm: React.FC = () => {
    const [form] = Form.useForm()
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [loading, setLoading] = useState(false)

    const [auth,] = useRecoilState(authState)
    const authService = useUserService()

    const showModal = () => {
        setIsModalOpen(true);
    };

    const HandleAnonymise = async (anonymise: boolean) => {
        setLoading(true)
        await authService.deleteAccount({ email: auth.username, IsAnonimise: anonymise })
        setLoading(false)
    };

    const Cancel = () => {
        setIsModalOpen(false);
    }

    const handleClose = () => {
        console.log("close")
        setIsModalOpen(false);
    }

    return (
        <>
            <Paragraph>
                In accordance with data protection laws, you have the right to request the deletion of your personal data. Please contact us at [contact email] to make your request. We will process it promptly and notify you once completed.
            </Paragraph>
            <Form form={form} onFinish={showModal}>
                <SubmitButton text={"Delete Account"} loading={loading} />
                <Modal width={800} onCancel={Cancel} closable={true} onClose={handleClose} title="Delete Account" open={isModalOpen} okButtonProps={{ loading: loading, }} footer={[
                    <Content style={{ display: "flex", justifyContent: "center", alignItems: "center", flexWrap: "wrap" }}>
                        <SubmitButton key={1} text={"Anonymise"} style={{ backgroundColor: "#d00000", color: "white" }} loading={loading} onClick={() => HandleAnonymise(true)} />
                        <SubmitButton key={2} text={"Delete Account"} style={{ color: "red", borderColor: "red", backgroundColor: "white" }} loading={loading} onClick={() => HandleAnonymise(false)} />
                    </Content>]}>
                    <Flex style={{ flexDirection: "column" }}>
                        <Typography> Are you sure you want to delete your account? This action is irreversible and all your data will be permanently lost.</Typography>
                        <ul>
                            <li key={1} style={{ fontWeight: 500 }}>This includes your profile, settings, and any content you've created.</li>
                            <li key={2} style={{ fontWeight: 500 }}>You will not be able to recover your account or any of its associated data.</li>
                        </ul>
                        <Typography>If you are sure, please confirm your decision by clicking the <span style={{ fontWeight: 500 }}>"Delete Account"</span> button below.</Typography>
                    </Flex>
                </Modal>
            </Form>
        </>
    )
}

export default DeleteAccountForm