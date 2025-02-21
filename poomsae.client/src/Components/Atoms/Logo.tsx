interface LogoProps {
    name: string
    src?: string
    size: "small" | "medium" | "big"
    style?: React.CSSProperties
}

const Logo: React.FC<LogoProps> = ({
    size, name, style, src = "logo.svg" }) => {
    const LogoStyle = {
        ...style,
        width: "100px",
        height: "65px",
    }
    const smallStyle = {
        ...style,
        width: "30px",
        height: "20px",
    }

    return (<> {size === "small" && <img style={smallStyle} src={src} alt={name} />}
        {size === "medium" && <img style={LogoStyle} src={src} alt={name} />}
        {size === "big" && <img style={LogoStyle} src={src} alt={name} />}
    </>
    )
}

export default Logo