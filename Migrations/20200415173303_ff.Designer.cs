﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewDawnWeb.Models;

namespace NewDawnWeb.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20200415173303_ff")]
    partial class ff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewDawnWeb.Models.CoinsOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseAmount")
                        .HasColumnType("int");

                    b.Property<int>("BonusAmount")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CoinsOffers");
                });

            modelBuilder.Entity("NewDawnWeb.Models.IMItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Discount")
                        .HasColumnType("smallint");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("HoverLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IMItems");
                });

            modelBuilder.Entity("NewDawnWeb.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("NewDawnWeb.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IssuerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SolverId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssuerId");

                    b.HasIndex("SolverId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("NewDawnWeb.Models.TicketReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("TicketReplies");
                });

            modelBuilder.Entity("NewDawnWeb.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaypalTxnId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("NewDawnWeb.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GmLevel")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLoginBanned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PassworResetExpire")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewDawnWeb.Models.News", b =>
                {
                    b.HasOne("NewDawnWeb.Models.User", "Publisher")
                        .WithMany("News")
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("NewDawnWeb.Models.Ticket", b =>
                {
                    b.HasOne("NewDawnWeb.Models.User", "Issuer")
                        .WithMany("IssuedTickets")
                        .HasForeignKey("IssuerId");

                    b.HasOne("NewDawnWeb.Models.User", "Solver")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("SolverId");
                });

            modelBuilder.Entity("NewDawnWeb.Models.TicketReply", b =>
                {
                    b.HasOne("NewDawnWeb.Models.Ticket", "Ticket")
                        .WithMany("TicketReplies")
                        .HasForeignKey("TicketId");

                    b.HasOne("NewDawnWeb.Models.User", "User")
                        .WithMany("TicketReplies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NewDawnWeb.Models.Transaction", b =>
                {
                    b.HasOne("NewDawnWeb.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
