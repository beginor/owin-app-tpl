SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: aspnet_role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE aspnet_role (
    id character varying(32) NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE aspnet_role OWNER TO postgres;

--
-- Name: aspnet_user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE aspnet_user (
    id character varying(32) NOT NULL,
    access_failed_count integer NOT NULL,
    email character varying(255) NOT NULL,
    email_confirmed boolean NOT NULL,
    lockout_enabled boolean NOT NULL,
    lockout_end_date_utc timestamp without time zone,
    password_hash character varying(255),
    phone_number character varying(128),
    phone_number_confirmed boolean NOT NULL,
    two_factor_enabled boolean NOT NULL,
    user_name character varying(255) NOT NULL,
    security_stamp character varying(255)
);


ALTER TABLE aspnet_user OWNER TO postgres;

--
-- Name: aspnet_user_claim; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE aspnet_user_claim (
    id integer NOT NULL,
    claim_type character varying(1024),
    claim_value character varying(1024),
    user_id character varying(32)
);


ALTER TABLE aspnet_user_claim OWNER TO postgres;

--
-- Name: aspnet_user_claim_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE aspnet_user_claim_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE aspnet_user_claim_id_seq OWNER TO postgres;

--
-- Name: aspnet_user_claim_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE aspnet_user_claim_id_seq OWNED BY aspnet_user_claim.id;


--
-- Name: aspnet_user_login; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE aspnet_user_login (
    user_id character varying(32) NOT NULL,
    login_provider character varying(128) NOT NULL,
    provider_key character varying(128) NOT NULL
);


ALTER TABLE aspnet_user_login OWNER TO postgres;

--
-- Name: aspnet_user_role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE aspnet_user_role (
    user_id character varying(32) NOT NULL,
    role_id character varying(32) NOT NULL
);


ALTER TABLE aspnet_user_role OWNER TO postgres;

--
-- Name: sample; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE sample (
    id integer NOT NULL,
    name character varying(32) NOT NULL,
    user_id character varying(32)
);


ALTER TABLE sample OWNER TO postgres;

--
-- Name: sample_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE sample_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE sample_id_seq OWNER TO postgres;

--
-- Name: sample_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE sample_id_seq OWNED BY sample.id;


--
-- Name: aspnet_user_claim id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY aspnet_user_claim ALTER COLUMN id SET DEFAULT nextval('aspnet_user_claim_id_seq'::regclass);


--
-- Name: sample id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY sample ALTER COLUMN id SET DEFAULT nextval('sample_id_seq'::regclass);

