-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Φιλοξενητής: 127.0.0.1
-- Χρόνος δημιουργίας: 12 Απρ 2021 στις 14:22:44
-- Έκδοση διακομιστή: 10.4.17-MariaDB
-- Έκδοση PHP: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Βάση δεδομένων: `hfinder`
--

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `house`
--

CREATE TABLE `house` (
  `idh` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `sellrent` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `house_info`
--

CREATE TABLE `house_info` (
  `idh` int(11) NOT NULL,
  `location` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `floor` int(11) NOT NULL,
  `sm` float NOT NULL,
  `rooms` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `heating_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `likehouse`
--

CREATE TABLE `likehouse` (
  `id` int(11) NOT NULL,
  `idh` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `users_login_info`
--

CREATE TABLE `users_login_info` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `users_personal_info`
--

CREATE TABLE `users_personal_info` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Ευρετήρια για άχρηστους πίνακες
--

--
-- Ευρετήρια για πίνακα `house`
--
ALTER TABLE `house`
  ADD PRIMARY KEY (`idh`);

--
-- Ευρετήρια για πίνακα `house_info`
--
ALTER TABLE `house_info`
  ADD PRIMARY KEY (`idh`);

--
-- Ευρετήρια για πίνακα `users_login_info`
--
ALTER TABLE `users_login_info`
  ADD PRIMARY KEY (`id`);

--
-- Ευρετήρια για πίνακα `users_personal_info`
--
ALTER TABLE `users_personal_info`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT για άχρηστους πίνακες
--

--
-- AUTO_INCREMENT για πίνακα `house`
--
ALTER TABLE `house`
  MODIFY `idh` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
