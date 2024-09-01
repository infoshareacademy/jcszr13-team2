﻿using AutoMapper;
using HotelHero.Database.Entities;
using HotelHero.Database.Repositiories.Reservations;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Interface;

namespace HotelHero.WebMVC.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public List<Reservation> GetReservations()
        {
            List<ReservationDTO> reservationDTO = _reservationRepository.GetAllReservations();
            List<Reservation> reservations = _mapper.Map < List<Reservation>>(reservationDTO);
            return reservations;
        }

        public List<Reservation> SearchForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople)
        {
            List<ReservationDTO> reservationDTO = _reservationRepository.SearchForReservations(searchCity, searchCheckInDate, searchCheckOutDate, searchAmountOfPeople);
            List<Reservation> reservations = _mapper.Map<List<Reservation>>(reservationDTO);
            return reservations;
        }

        public List<Reservation> SearchWithFiltersForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople, decimal? costPerNight, int? stars, float? rating, bool isFreeWiFi, bool isPrivateParking, bool isRestaurant, bool isBar)
        {
            List<ReservationDTO> reservationDTO = _reservationRepository.SearchWithFiltersForReservations(searchCity, searchCheckInDate, searchCheckOutDate, searchAmountOfPeople, costPerNight, stars, rating, isFreeWiFi, isPrivateParking, isRestaurant, isBar);
            List<Reservation> reservations = _mapper.Map<List<Reservation>>(reservationDTO);
            return reservations;
        }

        public Reservation GetReservationById(int id)
        {
            ReservationDTO reservationDTO = _reservationRepository.GetReservation(id);
            Reservation reservation = _mapper.Map<Reservation>(reservationDTO);
            return reservation;
        }

        public void MakeReservation(int reservationId, string userEmail)
        {
            _reservationRepository.MakeReservation(reservationId, userEmail);   
        }

        public void PayReservation(int reservationId)
        {
            _reservationRepository.PayReservation(reservationId);
        }

        public void CancelReservation(int reservationId)
        {
            _reservationRepository.CancelReservation(reservationId);
        }
    }
}
