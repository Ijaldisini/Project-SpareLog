PGDMP      	                }         	   DBProject    17.4    17.4 <    a           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            b           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            c           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            d           1262    16713 	   DBProject    DATABASE     q   CREATE DATABASE "DBProject" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'id-ID';
    DROP DATABASE "DBProject";
                     postgres    false            �            1259    16757    users    TABLE     X   CREATE TABLE public.users (
    id_user integer NOT NULL,
    password text NOT NULL
);
    DROP TABLE public.users;
       public         heap r       postgres    false            �            1259    16756    User_id_user_seq    SEQUENCE     �   CREATE SEQUENCE public."User_id_user_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."User_id_user_seq";
       public               postgres    false    230            e           0    0    User_id_user_seq    SEQUENCE OWNED BY     H   ALTER SEQUENCE public."User_id_user_seq" OWNED BY public.users.id_user;
          public               postgres    false    229            �            1259    16715    aktivitas_stok    TABLE     �   CREATE TABLE public.aktivitas_stok (
    id_aktivitas integer NOT NULL,
    barang_id_barang integer NOT NULL,
    supplier_id_supplier integer NOT NULL
);
 "   DROP TABLE public.aktivitas_stok;
       public         heap r       postgres    false            �            1259    16714    aktivitas_stok_id_aktivitas_seq    SEQUENCE     �   CREATE SEQUENCE public.aktivitas_stok_id_aktivitas_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.aktivitas_stok_id_aktivitas_seq;
       public               postgres    false    218            f           0    0    aktivitas_stok_id_aktivitas_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.aktivitas_stok_id_aktivitas_seq OWNED BY public.aktivitas_stok.id_aktivitas;
          public               postgres    false    217            �            1259    16722    barang    TABLE     �   CREATE TABLE public.barang (
    id_barang integer NOT NULL,
    nama_barang character varying(225) NOT NULL,
    harga_barang integer NOT NULL,
    stok_barang integer NOT NULL,
    hpp integer NOT NULL,
    supplier_id_supplier integer NOT NULL
);
    DROP TABLE public.barang;
       public         heap r       postgres    false            �            1259    16721    barang_id_barang_seq    SEQUENCE     �   CREATE SEQUENCE public.barang_id_barang_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.barang_id_barang_seq;
       public               postgres    false    220            g           0    0    barang_id_barang_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.barang_id_barang_seq OWNED BY public.barang.id_barang;
          public               postgres    false    219            �            1259    16729    detail_transaksi    TABLE     �   CREATE TABLE public.detail_transaksi (
    id_detail_transaksi integer NOT NULL,
    barang_id_barang integer NOT NULL,
    transaksi_id_transaksi integer NOT NULL,
    laporan_penjualan_id_laporan integer NOT NULL,
    user_id_user integer NOT NULL
);
 $   DROP TABLE public.detail_transaksi;
       public         heap r       postgres    false            �            1259    16728 (   detail_transaksi_id_detail_transaksi_seq    SEQUENCE     �   CREATE SEQUENCE public.detail_transaksi_id_detail_transaksi_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ?   DROP SEQUENCE public.detail_transaksi_id_detail_transaksi_seq;
       public               postgres    false    222            h           0    0 (   detail_transaksi_id_detail_transaksi_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public.detail_transaksi_id_detail_transaksi_seq OWNED BY public.detail_transaksi.id_detail_transaksi;
          public               postgres    false    221            �            1259    16736    laporan_penjualan    TABLE     n   CREATE TABLE public.laporan_penjualan (
    id_laporan integer NOT NULL,
    tanggal_periode date NOT NULL
);
 %   DROP TABLE public.laporan_penjualan;
       public         heap r       postgres    false            �            1259    16735     laporan_penjualan_id_laporan_seq    SEQUENCE     �   CREATE SEQUENCE public.laporan_penjualan_id_laporan_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 7   DROP SEQUENCE public.laporan_penjualan_id_laporan_seq;
       public               postgres    false    224            i           0    0     laporan_penjualan_id_laporan_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public.laporan_penjualan_id_laporan_seq OWNED BY public.laporan_penjualan.id_laporan;
          public               postgres    false    223            �            1259    16743    supplier    TABLE     u   CREATE TABLE public.supplier (
    id_supplier integer NOT NULL,
    nama_supplier character varying(20) NOT NULL
);
    DROP TABLE public.supplier;
       public         heap r       postgres    false            �            1259    16742    supplier_id_supplier_seq    SEQUENCE     �   CREATE SEQUENCE public.supplier_id_supplier_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.supplier_id_supplier_seq;
       public               postgres    false    226            j           0    0    supplier_id_supplier_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.supplier_id_supplier_seq OWNED BY public.supplier.id_supplier;
          public               postgres    false    225            �            1259    16750 	   transaksi    TABLE     �   CREATE TABLE public.transaksi (
    id_transaksi integer NOT NULL,
    nama_transaksi character varying(20) NOT NULL,
    tanggal_transaksi date NOT NULL,
    jumlah_barang integer NOT NULL,
    total_transaksi numeric(10,2) NOT NULL
);
    DROP TABLE public.transaksi;
       public         heap r       postgres    false            �            1259    16749    transaksi_id_transaksi_seq    SEQUENCE     �   CREATE SEQUENCE public.transaksi_id_transaksi_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.transaksi_id_transaksi_seq;
       public               postgres    false    228            k           0    0    transaksi_id_transaksi_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.transaksi_id_transaksi_seq OWNED BY public.transaksi.id_transaksi;
          public               postgres    false    227            �           2604    16718    aktivitas_stok id_aktivitas    DEFAULT     �   ALTER TABLE ONLY public.aktivitas_stok ALTER COLUMN id_aktivitas SET DEFAULT nextval('public.aktivitas_stok_id_aktivitas_seq'::regclass);
 J   ALTER TABLE public.aktivitas_stok ALTER COLUMN id_aktivitas DROP DEFAULT;
       public               postgres    false    218    217    218            �           2604    16725    barang id_barang    DEFAULT     t   ALTER TABLE ONLY public.barang ALTER COLUMN id_barang SET DEFAULT nextval('public.barang_id_barang_seq'::regclass);
 ?   ALTER TABLE public.barang ALTER COLUMN id_barang DROP DEFAULT;
       public               postgres    false    220    219    220            �           2604    16732 $   detail_transaksi id_detail_transaksi    DEFAULT     �   ALTER TABLE ONLY public.detail_transaksi ALTER COLUMN id_detail_transaksi SET DEFAULT nextval('public.detail_transaksi_id_detail_transaksi_seq'::regclass);
 S   ALTER TABLE public.detail_transaksi ALTER COLUMN id_detail_transaksi DROP DEFAULT;
       public               postgres    false    222    221    222            �           2604    16739    laporan_penjualan id_laporan    DEFAULT     �   ALTER TABLE ONLY public.laporan_penjualan ALTER COLUMN id_laporan SET DEFAULT nextval('public.laporan_penjualan_id_laporan_seq'::regclass);
 K   ALTER TABLE public.laporan_penjualan ALTER COLUMN id_laporan DROP DEFAULT;
       public               postgres    false    223    224    224            �           2604    16746    supplier id_supplier    DEFAULT     |   ALTER TABLE ONLY public.supplier ALTER COLUMN id_supplier SET DEFAULT nextval('public.supplier_id_supplier_seq'::regclass);
 C   ALTER TABLE public.supplier ALTER COLUMN id_supplier DROP DEFAULT;
       public               postgres    false    225    226    226            �           2604    16753    transaksi id_transaksi    DEFAULT     �   ALTER TABLE ONLY public.transaksi ALTER COLUMN id_transaksi SET DEFAULT nextval('public.transaksi_id_transaksi_seq'::regclass);
 E   ALTER TABLE public.transaksi ALTER COLUMN id_transaksi DROP DEFAULT;
       public               postgres    false    228    227    228            �           2604    16760    users id_user    DEFAULT     o   ALTER TABLE ONLY public.users ALTER COLUMN id_user SET DEFAULT nextval('public."User_id_user_seq"'::regclass);
 <   ALTER TABLE public.users ALTER COLUMN id_user DROP DEFAULT;
       public               postgres    false    230    229    230            R          0    16715    aktivitas_stok 
   TABLE DATA           ^   COPY public.aktivitas_stok (id_aktivitas, barang_id_barang, supplier_id_supplier) FROM stdin;
    public               postgres    false    218   5J       T          0    16722    barang 
   TABLE DATA           n   COPY public.barang (id_barang, nama_barang, harga_barang, stok_barang, hpp, supplier_id_supplier) FROM stdin;
    public               postgres    false    220   RJ       V          0    16729    detail_transaksi 
   TABLE DATA           �   COPY public.detail_transaksi (id_detail_transaksi, barang_id_barang, transaksi_id_transaksi, laporan_penjualan_id_laporan, user_id_user) FROM stdin;
    public               postgres    false    222   �J       X          0    16736    laporan_penjualan 
   TABLE DATA           H   COPY public.laporan_penjualan (id_laporan, tanggal_periode) FROM stdin;
    public               postgres    false    224   �J       Z          0    16743    supplier 
   TABLE DATA           >   COPY public.supplier (id_supplier, nama_supplier) FROM stdin;
    public               postgres    false    226   K       \          0    16750 	   transaksi 
   TABLE DATA           t   COPY public.transaksi (id_transaksi, nama_transaksi, tanggal_transaksi, jumlah_barang, total_transaksi) FROM stdin;
    public               postgres    false    228   EK       ^          0    16757    users 
   TABLE DATA           2   COPY public.users (id_user, password) FROM stdin;
    public               postgres    false    230   �K       l           0    0    User_id_user_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."User_id_user_seq"', 1, true);
          public               postgres    false    229            m           0    0    aktivitas_stok_id_aktivitas_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.aktivitas_stok_id_aktivitas_seq', 1, false);
          public               postgres    false    217            n           0    0    barang_id_barang_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.barang_id_barang_seq', 1, false);
          public               postgres    false    219            o           0    0 (   detail_transaksi_id_detail_transaksi_seq    SEQUENCE SET     W   SELECT pg_catalog.setval('public.detail_transaksi_id_detail_transaksi_seq', 1, false);
          public               postgres    false    221            p           0    0     laporan_penjualan_id_laporan_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.laporan_penjualan_id_laporan_seq', 1, false);
          public               postgres    false    223            q           0    0    supplier_id_supplier_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.supplier_id_supplier_seq', 1, true);
          public               postgres    false    225            r           0    0    transaksi_id_transaksi_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.transaksi_id_transaksi_seq', 5, true);
          public               postgres    false    227            �           2606    16720     aktivitas_stok aktivitas_stok_pk 
   CONSTRAINT     h   ALTER TABLE ONLY public.aktivitas_stok
    ADD CONSTRAINT aktivitas_stok_pk PRIMARY KEY (id_aktivitas);
 J   ALTER TABLE ONLY public.aktivitas_stok DROP CONSTRAINT aktivitas_stok_pk;
       public                 postgres    false    218            �           2606    16727    barang barang_pk 
   CONSTRAINT     U   ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_pk PRIMARY KEY (id_barang);
 :   ALTER TABLE ONLY public.barang DROP CONSTRAINT barang_pk;
       public                 postgres    false    220            �           2606    16734 $   detail_transaksi detail_transaksi_pk 
   CONSTRAINT     s   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detail_transaksi_pk PRIMARY KEY (id_detail_transaksi);
 N   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detail_transaksi_pk;
       public                 postgres    false    222            �           2606    16741 &   laporan_penjualan laporan_penjualan_pk 
   CONSTRAINT     l   ALTER TABLE ONLY public.laporan_penjualan
    ADD CONSTRAINT laporan_penjualan_pk PRIMARY KEY (id_laporan);
 P   ALTER TABLE ONLY public.laporan_penjualan DROP CONSTRAINT laporan_penjualan_pk;
       public                 postgres    false    224            �           2606    16748    supplier supplier_pk 
   CONSTRAINT     [   ALTER TABLE ONLY public.supplier
    ADD CONSTRAINT supplier_pk PRIMARY KEY (id_supplier);
 >   ALTER TABLE ONLY public.supplier DROP CONSTRAINT supplier_pk;
       public                 postgres    false    226            �           2606    16755    transaksi transaksi_pk 
   CONSTRAINT     ^   ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_pk PRIMARY KEY (id_transaksi);
 @   ALTER TABLE ONLY public.transaksi DROP CONSTRAINT transaksi_pk;
       public                 postgres    false    228            �           2606    16762    users user_pk 
   CONSTRAINT     P   ALTER TABLE ONLY public.users
    ADD CONSTRAINT user_pk PRIMARY KEY (id_user);
 7   ALTER TABLE ONLY public.users DROP CONSTRAINT user_pk;
       public                 postgres    false    230            �           2606    16763 '   aktivitas_stok aktivitas_stok_barang_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.aktivitas_stok
    ADD CONSTRAINT aktivitas_stok_barang_fk FOREIGN KEY (barang_id_barang) REFERENCES public.barang(id_barang);
 Q   ALTER TABLE ONLY public.aktivitas_stok DROP CONSTRAINT aktivitas_stok_barang_fk;
       public               postgres    false    4782    220    218            �           2606    16768 )   aktivitas_stok aktivitas_stok_supplier_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.aktivitas_stok
    ADD CONSTRAINT aktivitas_stok_supplier_fk FOREIGN KEY (supplier_id_supplier) REFERENCES public.supplier(id_supplier);
 S   ALTER TABLE ONLY public.aktivitas_stok DROP CONSTRAINT aktivitas_stok_supplier_fk;
       public               postgres    false    218    4788    226            �           2606    16773    barang barang_supplier_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_supplier_fk FOREIGN KEY (supplier_id_supplier) REFERENCES public.supplier(id_supplier);
 C   ALTER TABLE ONLY public.barang DROP CONSTRAINT barang_supplier_fk;
       public               postgres    false    220    4788    226            �           2606    16778 +   detail_transaksi detail_transaksi_barang_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detail_transaksi_barang_fk FOREIGN KEY (barang_id_barang) REFERENCES public.barang(id_barang);
 U   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detail_transaksi_barang_fk;
       public               postgres    false    222    4782    220            �           2606    16783 6   detail_transaksi detail_transaksi_laporan_penjualan_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detail_transaksi_laporan_penjualan_fk FOREIGN KEY (laporan_penjualan_id_laporan) REFERENCES public.laporan_penjualan(id_laporan);
 `   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detail_transaksi_laporan_penjualan_fk;
       public               postgres    false    222    4786    224            �           2606    16788 .   detail_transaksi detail_transaksi_transaksi_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detail_transaksi_transaksi_fk FOREIGN KEY (transaksi_id_transaksi) REFERENCES public.transaksi(id_transaksi);
 X   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detail_transaksi_transaksi_fk;
       public               postgres    false    222    4790    228            �           2606    16793 )   detail_transaksi detail_transaksi_user_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detail_transaksi_user_fk FOREIGN KEY (user_id_user) REFERENCES public.users(id_user);
 S   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detail_transaksi_user_fk;
       public               postgres    false    222    4792    230            R      x������ � �      T   �   x�3�t*-�Tp�/N��42 NSNCm�e��s��JY¥�9�s2��K���8MMA�Ɯ&��`YS�F�Լ�|N#����D��55%�(1C�X�7��(1O!�� �����М�� �&F��� D�)D      V      x������ � �      X      x������ � �      Z      x�3�H-*I���K����� .��      \   T   x�U�1
�0D�z�.	��]��6ې���$���[=�~U-#��`&�0�aAY�|��ġ�+��fSC����g4BǺg����      ^      x�3�tL���342����� !�l     