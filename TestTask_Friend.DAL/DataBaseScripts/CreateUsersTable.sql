﻿\connect FriendDataBase;

create table "Users"
(
    "Id"       integer generated by default as identity
        constraint "PK_Users"
            primary key,
    "Phone"    text not null,
    "Login"    text not null,
    "Password" text not null,
    "Name"     text not null,
    "Birth"    date not null,
    "Tg"       text,
    "Email"    text
);

alter table "Users"
    owner to postgres;

create unique index "IX_Users_Login"
    on "Users" ("Login");